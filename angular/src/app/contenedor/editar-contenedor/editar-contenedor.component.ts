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
  EstadoServiceProxy,
  EstadoListDto,
  GetContenedorForEditOutput ,
  EditContenedorInput   
} from '@shared/service-proxies/service-proxies';
import {MatSelectModule} from '@angular/material/select';

@Component({
  selector: 'app-editar-contenedor',
  templateUrl: './editar-contenedor.component.html',
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
export class EditarContenedorComponent extends AppComponentBase implements OnInit {

  saving = false;
  filter: string = ''; 
  contenedor: EditContenedorInput = new EditContenedorInput(); 
  estados: EstadoListDto[] = [];
  tipo:boolean = false;
 
  constructor(
    injector: Injector,
    private _contenedorService: ContenedorServiceProxy,
    private _estadoService: EstadoServiceProxy,
    private _dialogRef: MatDialogRef<EditarContenedorComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._contenedorService
      .getContenedorForEdit(this._id)
      .subscribe((result: GetContenedorForEditOutput) => {
        console.info(result);
        this.contenedor.init(result); 
        this.getEstados();   
      });
  }

  save(): void {
    this.saving = true;   

    this._contenedorService
      .editContenedor(this.contenedor)
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
      console.info(this.estados); 
    });  

  }

}
