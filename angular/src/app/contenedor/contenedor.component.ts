import { Component, Injector, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from '@shared/paged-listing-component-base';
import { ContenedorServiceProxy, ContenedorListDto, ContenedorDto} from '@shared/service-proxies/service-proxies';
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
export class ContenedorComponent extends PagedListingComponentBase<ContenedorDto>  {
  
  
  protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
    throw new Error("Method not implemented.");
  }
  protected delete(entity: any): void {
    throw new Error("Method not implemented.");
  }

  keyword = '';
  contenedores: ContenedorListDto[] = [];

  constructor(
        injector: Injector,
        private _contenedorService: ContenedorServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
  }

  ngOnInit() {
    this.getContenedores();
  }

  refresh(): void {
    this.getDataPage(this.pageNumber);
  }

  getContenedores(): void {
    this._contenedorService.getContenedores(this.keyword).subscribe((result) => {
      this.contenedores = result.items;  
      console.info( this.contenedores );     
    });
  }
  createContenedor(): void {
    this.showCreateOrEditRoleDialog();
  }

  editContenedor(contenedor: ContenedorDto): void {
    this.showCreateOrEditRoleDialog(contenedor.id);
  }

  showCreateOrEditRoleDialog(id?: number): void {
    let createOrEditRoleDialog;
    if (id === undefined || id <= 0) {
        createOrEditRoleDialog = this._dialog.open(CrearContenedorComponent);
    } else {
        createOrEditRoleDialog = this._dialog.open(EditarContenedorComponent, {
            data: id
        });
    }

    createOrEditRoleDialog.afterClosed().subscribe(result => {
        if (result) {
            this.refresh();
        }
    });
}

}
