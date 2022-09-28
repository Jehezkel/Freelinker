import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IntegrationsService } from '../services/integrations.service';
import { IntegrationToken } from '../models/integration-token.model';

@Injectable()
export class AllegroInterceptor implements HttpInterceptor {
  token: string;
  constructor(integrationService: IntegrationsService) {
    integrationService
      .getBearerToken('allegro')
      .subscribe((data: IntegrationToken) => (this.token = data.tokenValue));
  }

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const isAllegroUrl = request.url.startsWith(environment.ALLEGRO_BASE_URL);
    if (isAllegroUrl) {
      request = request.clone({
        setHeaders: {
          Authorization: `bearer-token-for-user ${this.token}`,
        },
      });
    }
    return next.handle(request);
  }
}
