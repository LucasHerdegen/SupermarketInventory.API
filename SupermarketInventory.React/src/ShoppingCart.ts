import { createContext } from "react";
import type { Product } from "./producto";

export interface CartItem extends Product {
  quantity: number;
}

type ShoppingCartContext = {
  cart: CartItem[];
  addProduct: (p: Product) => void;
  removeProduct: (p: Product) => void;
};

export const ShopingCart = createContext<ShoppingCartContext>({
  cart: [],
  addProduct: () => {},
  removeProduct: () => {},
});