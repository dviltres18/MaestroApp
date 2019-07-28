import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MostrarViajeComponent } from './mostrar-viaje.component';

describe('MostrarViajeComponent', () => {
  let component: MostrarViajeComponent;
  let fixture: ComponentFixture<MostrarViajeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MostrarViajeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MostrarViajeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
