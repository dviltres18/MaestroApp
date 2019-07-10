import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearContenedorComponent } from './crear-contenedor.component';

describe('CrearContenedorComponent', () => {
  let component: CrearContenedorComponent;
  let fixture: ComponentFixture<CrearContenedorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrearContenedorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrearContenedorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
