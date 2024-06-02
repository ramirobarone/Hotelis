import { Address } from "./Address";

export interface Hotel {
  id: number;
  name: string;
  description: string;
  metaDescription: string;
  address: Address
  meta: string;
  email: string;
  codeArea: number;
  phoneNumber: number;
  image: string;

}
