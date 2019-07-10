import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { ContenedorServiceProxy, CrearContenedorInput} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-crear-contenedor',
  templateUrl: './crear-contenedor.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class CrearContenedorComponent extends AppComponentBase implements OnInit {

  saving = false;
  contenedor: CrearContenedorInput = new CrearContenedorInput();
  

  constructor(
    injector: Injector,
    private contenedorServiceProxy: ContenedorServiceProxy,
     private _dialogRef: MatDialogRef<CrearContenedorComponent>   
  ) {
    super(injector);
  }

  ngOnInit(): void {
    
  }

  save(): void {
    this.saving = true;
    
    const contenedor = new CrearContenedorInput();
    contenedor.init(this.contenedor);

    this.contenedorServiceProxy
      .crearContenedor(contenedor)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }

}
