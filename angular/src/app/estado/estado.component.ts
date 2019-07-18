import { Component, Injector, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from '@shared/paged-listing-component-base';
import { EstadoServiceProxy, EstadoListDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { CrearEstadoComponent } from './crear-estado/crear-estado.component';
import { EditarEstadoComponent } from './editar-estado/editar-estado.component';

export interface TipoEstado {
  value: boolean;
  viewValue: string;
}
@Component({
  templateUrl: './estado.component.html',
  animations: [appModuleAnimation()],
  styles: [
      `
        mat-form-field {
          padding: 10px;
        }
      `
  ]
})
export class EstadoComponent extends AppComponentBase implements  OnInit {

  keyword = '';
  estados: EstadoListDto[] = [];
  type:boolean = true;
  tipos: TipoEstado[] = [
    {value: true, viewValue: 'Viaje'},
    {value: false, viewValue: 'Contenedor'}    
  ];

  constructor(
        injector: Injector,
        private _estadoService: EstadoServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
  }

  ngOnInit(): void {
    this.getEstados();
  }

delete(estado: EstadoListDto): void {
    abp.message.confirm(
        this.l('EstadoDeleteWarningMessage', estado.nombre),
        (result: boolean) => {
            if (result) {
                this._estadoService
                    .deleteEstado(estado.id)
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
    this.getEstados();
  }

  getEstados(): void {
    this._estadoService.getEstados(this.keyword,this.type).subscribe((result) => {
      this.estados = result.items; 
    
    });
  }
  createEstado(): void {
    this.showCreateOrEditEstadoDialog();
  }

  editEstado(estado: EstadoListDto): void {
    this.showCreateOrEditEstadoDialog(estado.id);
  }

  showCreateOrEditEstadoDialog(id?: number): void {
    let createOrEditEstadoDialog;
    if (id === undefined || id <= 0) {
      createOrEditEstadoDialog = this._dialog.open(CrearEstadoComponent);
    } else {
      createOrEditEstadoDialog = this._dialog.open(EditarEstadoComponent, {
            data: id
        });
    }

    createOrEditEstadoDialog.afterClosed().subscribe(result => {
        if (result) {
            this.refresh();
        }
      });
    }

  selectTipoEstado(value): void{
      this.refresh();
  }


}
