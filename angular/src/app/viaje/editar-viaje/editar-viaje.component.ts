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
  EstadoServiceProxy,
  EstadoListDto,
  GetViajeForEditOutput ,
  EditViajeInput   
} from '@shared/service-proxies/service-proxies';
import {MatSelectModule} from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import * as moment from 'moment';
import { FormControl } from '@angular/forms';



@Component({
  selector: 'app-editar-viaje',
  templateUrl: './editar-viaje.component.html',
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
export class EditarViajeComponent  extends AppComponentBase implements OnInit {

  saving = false;
  filter: string = ''; 
  viaje: EditViajeInput = new EditViajeInput(); 
  estados: EstadoListDto[] = [];
  tipo:boolean = true;
  fechaInicioView = new FormControl(new Date());
  fechaFinView = new FormControl(new Date());
  

  hoy:Date = new Date();
  minDateInicio = new Date(this.hoy.getFullYear(),this.hoy.getMonth(),this.hoy.getDate());  
  maxDateInicio = new Date(2020, 0, 1); 
  minDateFin = this.minDateInicio;  
  maxDateFin = new Date(2020, 0, 1);
 
  constructor(
    injector: Injector,
    private _viajeService: ViajeServiceProxy,
    private _estadoService: EstadoServiceProxy,
    private _dialogRef: MatDialogRef<EditarViajeComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._viajeService
      .getViajeForEdit(this._id)
      .subscribe((result: GetViajeForEditOutput) => {      
        this.viaje.init(result); 
        this.getEstados();   
        this.fechaInicioView = new FormControl((this.viaje.fechaInicio).toISOString());  
        this.fechaFinView = new FormControl((this.viaje.fechaFin).toISOString());       
        
      });
  }

  save(): void {
    this.saving = true;   

    this._viajeService
      .editViaje(this.viaje)
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

  getEstados(): void{
    this._estadoService.getEstados(this.filter,this.tipo).subscribe((result) => {
      this.estados = result.items;   
     
    });  

  }
  addEventFechaInicio(type: string, event: MatDatepickerInputEvent<Date>) {
    this.minDateFin = event.value;
    this.minDateInicio = event.value;   
  }

  addEventFechaFin(type: string, event: MatDatepickerInputEvent<Date>) {  
   this.minDateFin = this.minDateInicio;
   this.maxDateInicio = event.value;
  }


}
