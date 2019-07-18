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
import { EstadoComponent } from './estado/estado.component';
import { CrearEstadoComponent } from './estado/crear-estado/crear-estado.component';
import { EditarEstadoComponent } from './estado/editar-estado/editar-estado.component';
import { ViajeComponent } from './viaje/viaje.component';
import { CrearViajeComponent } from './viaje/crear-viaje/crear-viaje.component';
import { EditarViajeComponent } from './viaje/editar-viaje/editar-viaje.component';

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
                    { path: 'viaje', component: ViajeComponent,
                    children: [
                        { path: '', component: CrearViajeComponent},   
                        { path: '', component: EditarViajeComponent}                              
                    ]
                    },                    
                    { path: 'contenedor', component: ContenedorComponent,
                    children: [
                        { path: '', component: CrearContenedorComponent},   
                        { path: '', component: EditarContenedorComponent}                              
                    ]
                    },
                    { path: 'estado', component: EstadoComponent,
                    children: [
                        { path: '', component: CrearEstadoComponent},   
                        { path: '', component: EditarEstadoComponent}                              
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
