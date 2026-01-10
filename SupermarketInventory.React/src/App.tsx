import { useEffect, useState } from 'react';
import type { CartItem, Product } from './producto';
import Loading from './Loading';
import ErrorApi from './ErrorApi';
import Products from './Products';
import { ShopingCart } from './ShoppingCart'
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
        console.log(error);
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
    const prod = cart.find(p => p.id === product.id);

    if (!prod)
    {
      setCart([...cart, {...product, quantity: 1}]);
      return;
    }

    prod.quantity++;
    console.log(prod);
    setCart(cart);
  }

  const removeProduct = (product: Product) => {
    if (product)

    setCart(cart.filter(p => p.id !== product.id));
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