export interface User {
  id: string;
  userName: string;
  email: string;
  password: string;
  phoneNumber?: string;
  phoneNumberConfirmed?: boolean;
  twoFactorEnabled?: boolean;
  lockoutEnabled?: boolean;
  accessFailedCount?: number;
  firstName?: string;
  lastName?: string;
  dob?: Date;
  isActive?: boolean;
  hireDate?: Date;
  confirmPassword: string;
}
