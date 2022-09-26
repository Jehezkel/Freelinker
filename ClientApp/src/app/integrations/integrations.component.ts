import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-integrations',
  templateUrl: './integrations.component.html',
  styleUrls: ['./integrations.component.scss'],
})
export class IntegrationsComponent implements OnInit {
  authCode: string = '';
  appName: string = '';
  constructor(private httpClient: HttpClient, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((qParams) => {
      if (qParams['name'] && qParams['code']) {
        console.log('no ba');
      }
    });
  }
  allegroAuth(): void {
    const clientId = 'fefecd4a6c7444b980730e25d7bc04df';
    const callbackUrl = 'https://localhost:4200/integrations?name=allegro';
    const fullUrl = `https://allegro.pl.allegrosandbox.pl/auth/oauth/authorize?response_type=code&client_id=${clientId}&redirect_uri=${callbackUrl}`;
    window.location.assign(fullUrl);
    console.log(fullUrl);
  }
}
