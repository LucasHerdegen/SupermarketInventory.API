import { createContext } from "react";
import type { CartItem, Product } from "./producto";

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