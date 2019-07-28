import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MostrarCargaComponent } from './mostrar-carga.component';

describe('MostrarCargaComponent', () => {
  let component: MostrarCargaComponent;
  let fixture: ComponentFixture<MostrarCargaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MostrarCargaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MostrarCargaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
