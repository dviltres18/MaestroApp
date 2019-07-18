import { Component, Injector, OnInit ,ElementRef, ViewChild} from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { EstadoServiceProxy, CrearEstadoInput } from '@shared/service-proxies/service-proxies';

export interface TipoEstado {
  value: boolean;
  viewValue: string;
}


@Component({
  selector: 'app-crear-estado',
  templateUrl: './crear-estado.component.html',
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
export class CrearEstadoComponent extends AppComponentBase implements OnInit {

  saving = false;
  estado: CrearEstadoInput = new CrearEstadoInput();
  type:boolean = true;
  tipos: TipoEstado[] = [
    {value: true, viewValue: 'Viaje'},
    {value: false, viewValue: 'Contenedor'}    
  ];

  constructor(
    injector: Injector,
    private estadoServiceProxy: EstadoServiceProxy,
     private _dialogRef: MatDialogRef<CrearEstadoComponent>   
  ) {
    super(injector);   
  }

  ngOnInit(): void {
    
  }

  save(): void {
    this.saving = true;
    
    const estado = new CrearEstadoInput();
    estado.init(this.estado);
    estado.tipo = this.type;
    this.estadoServiceProxy
      .crearEstado(estado)
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

  selectTipoEstado(value): void{
   this.type=value;
  }

}
