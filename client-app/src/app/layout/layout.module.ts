import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MinimalComponent } from './minimal/minimal.component';



@NgModule({
  declarations: [
    MinimalComponent
  ],
  exports: [
    MinimalComponent
  ],
  imports: [
    CommonModule
  ]
})
export class LayoutModule { }
