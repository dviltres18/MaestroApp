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

@Component({
  selector: 'app-viaje',
  templateUrl: './viaje.component.html',
  animations: [appModuleAnimation()],
  styles: [
      `
        mat-form-field {
          padding: 10px;
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

delete(viaje: ViajeListDto): void {
    abp.message.confirm(
        this.l('ViajeDeleteWarningMessage', viaje.destino),
        (result: boolean) => {
            if (result) {
                this._viajeService
                    .deleteViaje(viaje.id)
                    .pipe(
                        finalize(() => {
                            abp.notify.success(this.l('SuccessfullyDeleted'));
                            this.refresh();
                        })
                    )
                    .subscribe(() => { });
            }
        }
    );
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

  finalizarViaje(viaje: ViajeListDto): void {

    let editViajeInput:EditViajeInput = new EditViajeInput()
    editViajeInput.id= viaje.id;

    abp.message.confirm(
        this.l('ViajeFinalizar', viaje.destino),
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

}
