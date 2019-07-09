import { Component, Injector, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from '@shared/paged-listing-component-base';
import { ContenedorServiceProxy, ContenedorListDto} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
//import { CreateRoleDialogComponent } from './create-role/create-role-dialog.component';
//import { EditRoleDialogComponent } from './edit-role/edit-role-dialog.component';

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
export class ContenedorComponent extends AppComponentBase implements OnInit {

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

  getContenedores(): void {
    this._contenedorService.getContenedores(this.keyword).subscribe((result) => {
      this.contenedores = result.items;  
      console.info( this.contenedores );     
    });
  }

}
