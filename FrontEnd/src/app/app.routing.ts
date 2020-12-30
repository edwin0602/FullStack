import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { VehicleComponent } from './business/vehicle/vehicle.component';

const routes: Routes =[
    { path: '', redirectTo: 'vehicles', pathMatch: 'full' },
    { path: 'vehicles',      component: VehicleComponent }
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes,{
      useHash: true
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
