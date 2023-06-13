using Newtonsoft.Json;
using ASIGNMENT_FPOLY.Models;
using ASIGNMENT_FPOLY.IServices;

namespace ASIGNMENT_FPOLY.Services
{
    public static class SessionServices
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            session.SetString(key, JsonConvert.SerializeObject(value, settings));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public static bool CheckObjInList(Guid id, List<Product> products)
        {
            return products.Any(x => x.Id == id);
        }
        public static void AddObjToListeSession<T>(ISession session, string key, T Obj)
        {
            var listObj = GetObjectFromJson<List<T>>(session, key);
            if (listObj == null) listObj = new List<T>();
            listObj.Add(Obj);
            SetObjectAsJson(session, key, listObj);
        }
        public static void RemoveProductToSession(ISession session, string key, Guid idProduct, IProductService productServices)
        {
            var listObj = GetObjectFromJson<List<Product>>(session, key);
            var obj = listObj.Find(item => item.Id == idProduct);
            productServices.ReStore(obj);
            listObj.Remove(obj);
            SetObjectAsJson(session, key, listObj);
        }

        public static void AddCartToSession(ISession session, string key, CartDetail cartDetail)
        {
            var listCartSession = GetObjectFromJson<List<CartDetail>>(session, key);
            if (listCartSession == null) listCartSession = new List<CartDetail>();
            var getCartDetail = listCartSession.Find(item => item.ProductId == cartDetail.ProductId);
            if (getCartDetail != null)
            {
                getCartDetail.Quantity += cartDetail.Quantity;
            }
            else
            {
                listCartSession.Add(cartDetail);
            }
            SetObjectAsJson(session, key, listCartSession);
        }

        public static void DeletaCartDetailSession(ISession session, string key, Guid id)
        {
            var listCartSession = GetObjectFromJson<List<CartDetail>>(session, key);
            listCartSession.Remove(listCartSession.Find(item => item.Id == id));
            SetObjectAsJson(session, key, listCartSession);
        }

    }
}
