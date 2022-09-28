import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class IntegrationsService {
  private API_BASE_URL = environment.API_BASE_URL;

  constructor(private httpClient: HttpClient) {}
  getBearerToken(appName: string) {
    const url = this.API_BASE_URL + '/Integration/' + appName;
    return this.httpClient.get(url);
  }
}
