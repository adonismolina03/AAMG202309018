namespace AAMG202309018.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<object> data = new List<object>();
        public static void AddBodegaEndpoints(this WebApplication app)
        {
            app.MapPost("/bodega", (string id, string producto) =>
            {
                data.Add(new { id, producto });
                return Results.Ok();
            }).AllowAnonymous();

            app.MapGet("/bodega/{id}", (string id) =>
            {
                var item = data.FirstOrDefault(x => x.GetType().GetProperty("id")?.GetValue(x)?.ToString() == id);
                if (item != null)
                {
                    return Results.Ok(item);
                }
                else
                {
                    return Results.NotFound();
                }
            }).AllowAnonymous();

            app.MapPut("/bodega/{id}", (string id, string producto) =>
            {
                var item = data.FirstOrDefault(x => x.GetType().GetProperty("id")?.GetValue(x)?.ToString() == id);
                if (item != null)
                {

                    item.GetType().GetProperty("producto")?.SetValue(item, producto);
                    return Results.Ok();
                }
                else
                {
                    return Results.NotFound();
                }
            }).AllowAnonymous();
        }
    }
}
