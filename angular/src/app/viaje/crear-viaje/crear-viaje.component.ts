import { Component, Injector, OnInit ,ElementRef, ViewChild} from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { ViajeServiceProxy, CrearViajeInput } from '@shared/service-proxies/service-proxies';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import * as moment from 'moment';


@Component({
  selector: 'app-crear-viaje',
  templateUrl: './crear-viaje.component.html',
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
export class CrearViajeComponent  extends AppComponentBase implements OnInit {

  
  saving = false;
  viaje: CrearViajeInput = new CrearViajeInput();
  hoy:Date = new Date();
  minDateInicio = new Date(this.hoy.getFullYear(),this.hoy.getMonth(),this.hoy.getDate());  
  maxDateInicio = new Date(2020, 0, 1); 
  minDateFin = this.minDateInicio;  
  maxDateFin = new Date(2020, 0, 1);
 

  constructor(
   
    injector: Injector,
    private viajeServiceProxy: ViajeServiceProxy,
     private _dialogRef: MatDialogRef<CrearViajeComponent>   
  ) {
    super(injector);   
    
  }

  ngOnInit(): void {
    
  }

  save(): void {
    this.saving = true;
    
    const viaje = new CrearViajeInput();
    viaje.init(this.viaje);
    
    var fechaInicio = moment(this.minDateInicio);
    viaje.fechaInicio = fechaInicio;

    var fechaFin = moment(this.minDateFin);
    viaje.fechaFin = fechaFin;
  

    this.viajeServiceProxy
      .crearViaje(viaje)
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

  addEventFechaInicio(type: string, event: MatDatepickerInputEvent<Date>) {
    this.minDateFin = event.value;
    this.minDateInicio = event.value;   
  }

  addEventFechaFin(type: string, event: MatDatepickerInputEvent<Date>) {  
   this.minDateFin = this.minDateInicio;
   this.maxDateInicio = event.value;
  }

}
