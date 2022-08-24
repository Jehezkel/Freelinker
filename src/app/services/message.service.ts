import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';

export enum MsgLevel {
  Error,
  Warning,
  Info,
  Success,
}
export class Message {
  id: number;
  content: string;
  level: MsgLevel;
  visibleSeconds: number;
  constructor(obj?: any) {
    this.id = obj.id || -1;
    this.content = obj.content || '';
    this.level = obj.level || MsgLevel.Info;
    this.visibleSeconds = obj.visibleSeconds || 2;
  }
}
@Injectable({
  providedIn: 'root',
})
export class MessageService {
  private messagesArray: Message[] = [];
  messages: Subject<Message[]> = new Subject<Message[]>();
  private idx = 0;

  constructor() {
    this.messages.next(this.messagesArray);
  }
  newMessage(msg: string, level: MsgLevel, visibleSeconds?: number) {
    const msgObject = {
      id: this.idx++,
      content: msg,
      level: level,
      visibleSeconds: visibleSeconds,
    };
    this.messagesArray.push(msgObject);
    this.messages.next(this.messagesArray);
    setTimeout(
      () => this.closeMessage(msgObject),
      1000 * msgObject.visibleSeconds
    );
  }
  closeMessage(msg: Message) {
    this.messagesArray = this.messagesArray.filter((m) => m.id !== msg.id);
    this.messages.next(this.messagesArray);
  }
  newError(msg: string): void {
    this.newMessage(msg, MsgLevel.Error, 10);
  }
  newWarning(msg: string): void {
    this.newMessage(msg, MsgLevel.Warning, 10);
  }
  newInfo(msg: string): void {
    this.newMessage(msg, MsgLevel.Info, 10);
  }
  newSuccess(msg: string): void {
    this.newMessage(msg, MsgLevel.Success, 10);
  }
}
