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
  ViajeServiceProxy,
  GetViajeForEditOutput,  
  CargaViajeInput, 
  ContenedorInViajeListDto 
} from '@shared/service-proxies/service-proxies';
import {MatSelectModule} from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import * as moment from 'moment';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-mostrar-carga',
  templateUrl: './mostrar-carga.component.html',
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
export class MostrarCargaComponent  extends AppComponentBase implements OnInit  {

  saving = false;
  filter: string = ''; 
  viaje: CargaViajeInput = new CargaViajeInput();    

  contenedoresViaje: ContenedorInViajeListDto[] = [];
 
  constructor(
    injector: Injector,
    private _viajeService: ViajeServiceProxy,   
    private _dialogRef: MatDialogRef<MostrarCargaComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._viajeService
      .getViajeForEdit(this._id)
      .subscribe((result: GetViajeForEditOutput) => {      
        this.viaje.init(result);       
        this.getContenedoresViaje();    
      });      
  }

  getContenedoresViaje(): void {
      this._viajeService.getContenedorViaje(this.viaje.id).subscribe((result) => {
        this.contenedoresViaje = result.items;
      });
    }
      

  close(result: any): void {
    this._dialogRef.close(result);
  }  
 
}
