export class User {
  id: number;
  username: string;
  email: string;
  /**
   *
   */
  constructor(object?: any) {
    this.id = object.id || -1;
    this.username = object.username || 'no user name';
    this.email = object.email || 'no email';
  }
}
