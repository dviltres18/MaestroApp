import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarContenedorComponent } from './editar-contenedor.component';

describe('EditarContenedorComponent', () => {
  let component: EditarContenedorComponent;
  let fixture: ComponentFixture<EditarContenedorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarContenedorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarContenedorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
