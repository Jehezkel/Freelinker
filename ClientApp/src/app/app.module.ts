import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';
import { IntegrationsComponent } from './integrations/integrations.component';
import { ProductGalleryComponent } from './products/product-gallery/product-gallery.component';
import { ImageUploadAreaComponent } from './products/image-upload-area/image-upload-area.component';
import { UserButtonComponent } from './navbar/user-button/user-button.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MessagesComponent } from './messages/messages.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JWTInterceptor } from './helpers/jwt.interceptor';
import { ProductFormComponent } from './products/product-form/product-form.component';
import { ProductFormGeneralComponent } from './products/product-form-general/product-form-general.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    ProductsComponent,
    IntegrationsComponent,
    ProductGalleryComponent,
    ImageUploadAreaComponent,
    UserButtonComponent,
    MessagesComponent,
    ProductFormComponent,
    ProductFormGeneralComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JWTInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
