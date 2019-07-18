import { Component, Injector, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from '@shared/paged-listing-component-base';
import { ContenedorServiceProxy, ContenedorListDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { CrearContenedorComponent } from './crear-contenedor/crear-contenedor.component';
import { EditarContenedorComponent } from './editar-contenedor/editar-contenedor.component';


@Component({
  templateUrl: './contenedor.component.html',
  animations: [appModuleAnimation()],
  styles: [
      `
        mat-form-field {
          padding: 10px;
        }
      `
  ]
})
export class ContenedorComponent extends AppComponentBase implements  OnInit
{
  
  keyword = '';
  contenedores: ContenedorListDto[] = [];

  constructor(
        injector: Injector,
        private _contenedorService: ContenedorServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
  }

  ngOnInit(): void {
    this.getContenedores();
  }

delete(contenedor: ContenedorListDto): void {
    abp.message.confirm(
        this.l('ContenedorDeleteWarningMessage', contenedor.nombre),
        (result: boolean) => {
            if (result) {
                this._contenedorService
                    .deleteContenedor(contenedor.id)
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
    this.getContenedores();
  }

  getContenedores(): void {
    this._contenedorService.getContenedores(this.keyword).subscribe((result) => {
      this.contenedores = result.items;  
      console.info( this.contenedores );     
    });
  }
  createContenedor(): void {
    this.showCreateOrEditContenedorDialog();
  }

  editContenedor(contenedor: ContenedorListDto): void {
    this.showCreateOrEditContenedorDialog(contenedor.id);
  }

  showCreateOrEditContenedorDialog(id?: number): void {
    let createOrEditContenedorDialog;
    if (id === undefined || id <= 0) {
      createOrEditContenedorDialog = this._dialog.open(CrearContenedorComponent);
    } else {
      createOrEditContenedorDialog = this._dialog.open(EditarContenedorComponent, {
            data: id
        });
    }

    createOrEditContenedorDialog.afterClosed().subscribe(result => {
        if (result) {
            this.refresh();
        }
    });
}

}
