import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ContenedorComponent } from './contenedor/contenedor.component';
import { CrearContenedorComponent } from './contenedor/crear-contenedor/crear-contenedor.component';
import { EditarContenedorComponent } from './contenedor/editar-contenedor/editar-contenedor.component';
import { ViajeComponent } from './viaje/viaje.component';
import { CrearViajeComponent } from './viaje/crear-viaje/crear-viaje.component';
import { EditarViajeComponent } from './viaje/editar-viaje/editar-viaje.component';
import { CargarViajeComponent } from './viaje/cargar-viaje/cargar-viaje.component';
import { MostrarCargaComponent } from './viaje/mostrar-carga/mostrar-carga.component';
import { MostrarViajeComponent } from './contenedor/mostrar-viaje/mostrar-viaje.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'viaje', component: ViajeComponent, data: { permission: 'Pages.Viajes' } , canActivate: [AppRouteGuard],
                    children: [
                        { path: '', component: CrearViajeComponent},   
                        { path: '', component: EditarViajeComponent},    
                        { path: '', component: CargarViajeComponent},
                        { path: '', component: MostrarCargaComponent}                                       
                    ]
                    },                    
                    { path: 'contenedor', component: ContenedorComponent, data: { permission: 'Pages.Contenedores' } , canActivate: [AppRouteGuard],
                    children: [
                        { path: '', component: CrearContenedorComponent},   
                        { path: '', component: EditarContenedorComponent},
                        { path: '', component: MostrarViajeComponent}                             
                    ]
                    },                   
                    { path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
