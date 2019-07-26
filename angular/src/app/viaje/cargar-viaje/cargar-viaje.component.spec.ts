import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CargarViajeComponent } from './cargar-viaje.component';

describe('CargarViajeComponent', () => {
  let component: CargarViajeComponent;
  let fixture: ComponentFixture<CargarViajeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CargarViajeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CargarViajeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
