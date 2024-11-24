import { NavbarComponent } from './navbar/navbar.component';
import { HeaderComponent } from './header/header.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import {MainComponent} from './main/main.component';
import {FooterComponent} from './footer/footer.component';

export const components: any[] = [
  NavbarComponent,
  HeaderComponent,
  SideNavComponent,
  MainComponent,
  FooterComponent
];

export * from './navbar/navbar.component';
export * from './header/header.component';
export * from './side-nav/side-nav.component';
export * from './main/main.component';
export * from './footer/footer.component';
