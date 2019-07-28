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
  ContenedorServiceProxy,
  ViajeContenedorListDto,
  GetContenedorForEditOutput,  
  EditContenedorInput
} from '@shared/service-proxies/service-proxies';
import {MatSelectModule} from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import * as moment from 'moment';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-mostrar-viaje',
  templateUrl: './mostrar-viaje.component.html',
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
export class MostrarViajeComponent  extends AppComponentBase implements OnInit {

  saving = false;
  filter: string = ''; 
  contenedor: GetContenedorForEditOutput = new GetContenedorForEditOutput();    

  viajesContenedores: ViajeContenedorListDto[] = [];
 
  constructor(
    injector: Injector,
    private _contenedorService: ContenedorServiceProxy,   
    private _dialogRef: MatDialogRef<MostrarViajeComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._contenedorService
      .getContenedorForEdit(this._id)
      .subscribe((result: GetContenedorForEditOutput) => {      
        this.contenedor.init(result);       
        this.getViajesContenedor();    
      });      
  }

  getViajesContenedor(): void {
      this._contenedorService.getViajesContenedores(this.contenedor.id).subscribe((result) => {
        this.viajesContenedores = result.items;
        console.info( this.viajesContenedores );
      });
    }
      

  close(result: any): void {
    this._dialogRef.close(result);
  } 

}
