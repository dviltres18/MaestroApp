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
  GetViajeForEditOutput ,
  CargaViajeInput,
  AddContenedorInput,
  ContenedorServiceProxy,
  ContenedoresDispViajeListDto ,
  ContenedorInViajeListDto 
} from '@shared/service-proxies/service-proxies';
import {MatSelectModule} from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import * as moment from 'moment';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-cargar-viaje',
  templateUrl: './cargar-viaje.component.html',
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
export class CargarViajeComponent  extends AppComponentBase implements OnInit {

  saving = false;
  filter: string = ''; 
  viaje: CargaViajeInput = new CargaViajeInput();     

  contenedoresDisp: ContenedoresDispViajeListDto[] = [];
  contenedoresViaje: ContenedorInViajeListDto[] = [];
 
  constructor(
    injector: Injector,
    private _viajeService: ViajeServiceProxy,   
    private _dialogRef: MatDialogRef<CargarViajeComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._viajeService
      .getViajeForEdit(this._id)
      .subscribe((result: GetViajeForEditOutput) => {      
        this.viaje.init(result); 
        this.getContenedoresDisp();
        this.getContenedoresViaje();    
       
      });
  }
    getContenedoresViaje(): void {
      this._viajeService.getContenedorViaje(this.viaje.id).subscribe((result) => {
        this.contenedoresViaje = result.items;
      });
    }
    
    getContenedoresDisp(): void {
      this._viajeService.getContenedoresDispViajes(this.viaje.id).subscribe((result) => {
        this.contenedoresDisp = result.items;      
      });
    }

  save(): void {
    this.saving = true;   

    this.viaje.contenedoresDisponibles = this.contenedoresDisp;
    this.viaje.contenedoresSelec = this.contenedoresViaje;

    this._viajeService
      .cargarViaje(this.viaje)
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

  addContenedorToViaje(contenedor): void  {       
    this.contenedoresViaje.push(contenedor);         
    this.deleteContenedorDisp(contenedor.contenedorId); 
  }

  deleteContenedor(id): void {    
    for(var i=0 ; i < this.contenedoresViaje.length; i++ ){
       if(this.contenedoresViaje[i].contenedorId ==id){
            this.contenedoresDisp.push(this.contenedoresViaje[i]);
            this.contenedoresViaje.splice (i,1);   
             
       }         
    }   
  }

  deleteContenedorDisp(id): void {
    for(var i=0 ; i < this.contenedoresDisp.length; i++ ){
       if(this.contenedoresDisp[i].contenedorId ==id)
          this.contenedoresDisp.splice (i,1);    
    }   
  }


}
