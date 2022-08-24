import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Message, MessageService, MsgLevel } from '../services/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss'],
})
export class MessagesComponent implements OnInit {
  messages: Message[] = [];
  constructor(private msgService: MessageService) {
    msgService.messages.subscribe((m) => {
      this.messages = m;
      console.log(m);
    });
  }

  ngOnInit(): void {}
  dismissMessage(msg: Message) {
    console.log('dismissing', msg);
    this.msgService.closeMessage(msg);
  }
  msgIsLevelOf(message: Message, messageLevel: string): boolean {
    let enumLevel: MsgLevel;
    switch (messageLevel) {
      case 'Error':
        enumLevel = MsgLevel.Error;
        break;
      case 'Warning':
        enumLevel = MsgLevel.Warning;
        break;
      case 'Info':
        enumLevel = MsgLevel.Info;
        break;
      case 'Success':
        enumLevel = MsgLevel.Success;
        break;
      default:
        enumLevel = MsgLevel.Info;
        break;
    }
    return message.level == enumLevel;
  }
}
