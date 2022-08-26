import { Component, OnInit } from '@angular/core';
import { MessageService } from '../services/message.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private msgService: MessageService) {}

  ngOnInit(): void {}
  pushMessage(): void {
    this.msgService.newError('xD');
    this.msgService.newInfo('MyInfo');
    this.msgService.newWarning('MyWarning');
    this.msgService.newSuccess('MysUkces');
  }
}
