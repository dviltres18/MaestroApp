import { Component, Injector, Inject, OnInit, Optional } from '@angular/core';
import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { 
  EstadoServiceProxy,
  EstadoListDto,
  GetEstadoForEditOutput ,
  EditEstadoInput   
} from '@shared/service-proxies/service-proxies';
import {MatSelectModule} from '@angular/material/select';

export interface TipoEstado {
  value: boolean;
  viewValue: string;
}

@Component({
  selector: 'app-editar-estado',
  templateUrl: './editar-estado.component.html',
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
export class EditarEstadoComponent extends AppComponentBase implements OnInit {

  saving = false;
  filter: string = ''; 
  estado: EditEstadoInput = new EditEstadoInput(); 
  estados: EstadoListDto[] = [];
  type:boolean = true;
  tipos: TipoEstado[] = [
    {value: true, viewValue: 'Viaje'},
    {value: false, viewValue: 'Contenedor'}    
  ];

 
  constructor(
    injector: Injector,   
    private _estadoService: EstadoServiceProxy,
    private _dialogRef: MatDialogRef<EditarEstadoComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._estadoService
      .getEstadoForEdit(this._id)
      .subscribe((result: GetEstadoForEditOutput) => {      
        this.estado.init(result);         
      });
  }

  save(): void {
    this.saving = true;   

    this._estadoService
      .editEstado(this.estado)
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
