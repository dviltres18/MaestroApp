import { Component, Injector, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from '@shared/paged-listing-component-base';
import { ViajeServiceProxy, ViajeListDto, EditViajeInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { CrearViajeComponent } from './crear-viaje/crear-viaje.component';
import { EditarViajeComponent } from './editar-viaje/editar-viaje.component';
import { CargarViajeComponent } from './cargar-viaje/cargar-viaje.component';

@Component({
  selector: 'app-viaje',
  templateUrl: './viaje.component.html',
  animations: [appModuleAnimation()],
  styles: [
      `
        mat-form-field {
          padding: 10px;
        }
        i {
          padding: 0px 8px; 
        }
      `
  ]
})
export class ViajeComponent  extends AppComponentBase implements  OnInit {

  keyword = '';
  viajes: ViajeListDto[] = [];

  constructor(
        injector: Injector,
        private _viajeService: ViajeServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
  }

  ngOnInit(): void {
    this.getViajes();
  }


  refresh(): void {
    this.getViajes();
  }

  getViajes(): void {
    this._viajeService.getViajes(this.keyword).subscribe((result) => {
      this.viajes = result.items;  
      console.info( this.viajes );     
    });
  }
  createViaje(): void {
    this.showCreateOrEditViajeDialog();
  }

  editViaje(viaje: ViajeListDto): void {
    this.showCreateOrEditViajeDialog(viaje.id);
  }

  cargarViaje(viaje: ViajeListDto): void {

    let cargarViajeDialog = this._dialog.open(CargarViajeComponent, {
       data: viaje.id
     });
     cargarViajeDialog.afterClosed().subscribe(result => {
       if (result) {
           this.refresh();
       }
   });
   }

  showCreateOrEditViajeDialog(id?: number): void {
      let createOrEditViajeDialog;
      if (id === undefined || id <= 0) {
        createOrEditViajeDialog = this._dialog.open(CrearViajeComponent);
      } else {
        createOrEditViajeDialog = this._dialog.open(EditarViajeComponent, {
              data: id
          });
      }

      createOrEditViajeDialog.afterClosed().subscribe(result => {
          if (result) {
              this.refresh();
          }
      });
  }

  iniciarViaje(viaje: ViajeListDto): void {

    let editViajeInput:EditViajeInput = new EditViajeInput()
    editViajeInput.id= viaje.id;

    abp.message.confirm(
        this.l('Iniciar Viaje a' +' '+ viaje.destino),
        (result: boolean) => {
            if (result) {
                this._viajeService
                    .iniciarViaje(editViajeInput)
                    .pipe(
                        finalize(() => {
                            abp.notify.success(this.l('Successfully'));
                            this.refresh();
                        })
                    )
                    .subscribe(() => { });
            }
        }
    );
 }


  finalizarViaje(viaje: ViajeListDto): void {

    let editViajeInput:EditViajeInput = new EditViajeInput()
    editViajeInput.id= viaje.id;
  
    abp.message.confirm(
        this.l('Finalizar Viaje' +' '+ viaje.destino),
        (result: boolean) => {
            if (result) {
                this._viajeService
                    .finalizarViaje(editViajeInput)
                    .pipe(
                        finalize(() => {
                            abp.notify.success(this.l('Successfully'));
                            this.refresh();
                        })
                    )
                    .subscribe(() => { });
            }
        }
    );
  }
  desabilitarAction(estado):boolean{
    let ok=false;
    if(estado == 1 || estado == 2)
      ok = true;
    return ok;
  }

  ocultarFinalizarViaje(estado):boolean{
    let ok=false;
    if(estado == 2)
      ok = true;
    return ok;
  }
  ocultarIniciarViaje(estado):boolean{
    let ok=false;
    if(estado == 1)
      ok = true;
    return ok;
  }
  
  ocultarCargarViaje(estado):boolean{
    let ok=false;
    if(estado == 1)
      ok = true;
    return ok;
  }

  
  

}
