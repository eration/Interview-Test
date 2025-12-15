import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  standalone: true,
  selector: 'app-users-list',
  imports: [CommonModule, FormsModule, RouterLink],
    templateUrl: './users-list.component.html',
})
export class UsersListComponent {

  allUsers: any[] = [];
  users: any[] = [];

  constructor(
    private userService: UserService
  ) {}

  ngOnInit() {
    this.loadUsers();
  }

  async loadUsers() {
    this.allUsers = await this.userService.getAllUsers();
    this.users = this.allUsers;
  }

  onFilter(e: any) {
    const filter = e.target.value.toLowerCase();
    console.log("filter",filter);
    this.users = this.allUsers.filter(user =>
      user.id.toLowerCase().includes(filter) ||
      user.userId.toLowerCase().includes(filter) ||
      user.name.toLowerCase().includes(filter) ||
      user.username.toLowerCase().includes(filter) 
    );
  }
}
