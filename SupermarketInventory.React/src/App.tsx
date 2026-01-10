import { useEffect, useState } from 'react';
import type { Product } from './producto';
import Loading from './Loading';
import ErrorApi from './ErrorApi';
import Products from './Products';
import { ShopingCart, type CartItem } from './ShoppingCart'
import Cart from './Cart'

function App()
{
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [cart, setCart] = useState<CartItem[]>([]);

  useEffect( () => {
    const fetchProducts = async() =>
    {
      try
      {
        const response = await fetch(`${import.meta.env.VITE_API_URL}/products`);

        if (!response.ok)
          throw new Error('Error al conectar con la api');

        setProducts(await response.json());
        
      }
      catch (error)
      {
        console.error(error);
        setError("Fallo la conexión al hacer fetch de los productos");
      }
      finally
      {
        setLoading(false);
      }
      
    }

    fetchProducts();
  }, [])

  if (loading)
    return <Loading />

  if (error)
    return <ErrorApi error={error}/>

  const addProduct = (product: Product) => {
    setCart(prevCart => {
      const itemExists = prevCart.find(item => item.id === product.id);

      if (itemExists)
        return prevCart.map(item => 
          item.id === product.id ? { ...item, quantity: item.quantity + 1 } : item
        );
      else
        return [...prevCart, { ...product, quantity: 1 }];
    });
  }

  const removeProduct = (product: Product) => {
    setCart(prevCart => {
      const itemExists = prevCart.find(item => item.id === product.id);

      if (!itemExists)
        return prevCart;

      if (itemExists.quantity > 1)
      
        return prevCart.map(item => 
          item.id === product.id ? { ...item, quantity: item.quantity - 1 } : item
        );
      else 
        return prevCart.filter(item => item.id !== product.id);
    });
  }
  
  if (products)
    return (
      <ShopingCart.Provider value={{cart, addProduct, removeProduct}}>
        <Products products={products} />
        <Cart/>
      </ShopingCart.Provider>
    ); 
}

export default App