export class User {
  id: number | undefined;
  userName: string | undefined;
  email: string | undefined;
  passwordHash: string | undefined;
  phoneNumber: string | undefined;
  phoneNumberConfirmed: boolean = false;
  twoFactorEnabled: boolean = false;
  lockoutEnabled: boolean = false;
  accessFailedCount: number = 0;
  firstName: string | undefined;
  lastName: string | undefined;
  dob: Date | undefined;
  isActive: boolean = true;
  hireDate: Date | undefined;
  constructor(init?: Partial<User>) {
    Object.assign(this, init);
  }
}
