import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { PostComponent } from './post/post.component';
import { LogingScreenComponent } from './loging-screen/loging-screen.component';
import { RegisterScreenComponent } from './register-screen/register-screen.component';

@NgModule({
  declarations: [
    AppComponent,
    PostComponent,
    LogingScreenComponent,
    RegisterScreenComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      {
        path: 'login',
        component: LogingScreenComponent
      },
      {
        path: 'register',
        component: RegisterScreenComponent
      }
    ])
  ],
  

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
