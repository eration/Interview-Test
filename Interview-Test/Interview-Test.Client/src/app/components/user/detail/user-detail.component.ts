import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
    standalone: true,
    selector: 'app-user-detail',
    imports: [CommonModule, RouterLink],
    templateUrl: './user-detail.component.html',
})
export class UserDetailComponent {

    userId:string = "";
    user:any = null;

    constructor(
        private route: ActivatedRoute,
        private userService: UserService
    ) {}

    ngOnInit() {
        this.userId = this.route.snapshot.params['id'];
        this.getUserDetail();
    }

    async getUserDetail() {
        this.user = await this.userService.getUserById(this.userId);
    }
}
