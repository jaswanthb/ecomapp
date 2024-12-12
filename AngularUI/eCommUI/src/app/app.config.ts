import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';

import { routes } from './app.routes';
import { CustomerServiceService } from './services/customer-service.service';
import { provideHttpClient } from '@angular/common/http';
import { SupplierService } from './services/supplier.service';


export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes, withComponentInputBinding()),
    {provide: CustomerServiceService},
    {provide: SupplierService},
    provideHttpClient()
  ]
};
