import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { concatMap, filter, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-integrations',
  templateUrl: './integrations.component.html',
  styleUrls: ['./integrations.component.scss'],
})
export class IntegrationsComponent implements OnInit {
  private API_BASE_URL = environment.API_BASE_URL;

  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.queryParamMap
      .pipe(filter((qparams) => qparams.has('name') && qparams.has('code')))
      .pipe(
        concatMap((queryParams) =>
          this.saveTokenResponse(
            queryParams.get('name'),
            queryParams.get('code')
          )
        )
      )
      .subscribe((data) => {
        this.removeQueryParams();
      });
  }
  saveTokenResponse(appName: string, tokenVal: string): Observable<any> {
    const url = `${this.API_BASE_URL}/Integration`;
    const body = {
      appName: appName,
      tokenValue: tokenVal,
    };
    return this.httpClient.post(url, body);
  }
  removeQueryParams() {
    const urlNoParams = this.router.url.substring(
      0,
      this.router.url.indexOf('?')
    );
    this.router.navigateByUrl(urlNoParams);
  }
  allegroAuth(): void {
    const clientId = 'fefecd4a6c7444b980730e25d7bc04df';
    const callbackUrl = 'https://localhost:4200/integrations?name=allegro';
    const fullUrl = `https://allegro.pl.allegrosandbox.pl/auth/oauth/authorize?response_type=code&client_id=${clientId}&redirect_uri=${callbackUrl}`;
    window.location.assign(fullUrl);
  }
}
