import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UserService {
  headers = { 'x-api-key': 'satidsompradit' };
  constructor(private http: HttpClient) {}

  getAllUsers() {
    return lastValueFrom(this.http.get<any[]>('http://localhost:44375/gateway/api/User/GetAllUsers', { headers: this.headers }));
  }

  getUserById(userId: string) {
    return lastValueFrom(this.http.get<any>(`http://localhost:44375/gateway/api/User/GetUserById/${userId}`, { headers: this.headers }));
  }
}
