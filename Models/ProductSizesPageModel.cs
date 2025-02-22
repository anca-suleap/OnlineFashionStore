using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineFashionStore.Data;

namespace OnlineFashionStore.Models
{
    public class ProductSizesPageModel: PageModel
    {
        public List<AssignedSizeData> AssignedSizeDataList;

        public void PopulateAssignedSizeData(OnlineFashionStoreContext context, Product product)
        {
            var allSizes = context.Size;
            var productSizes = new HashSet<int>(
                product.ProductSizes.Select(c => c.SizeID));

            AssignedSizeDataList = new List<AssignedSizeData>();
            foreach (var size in allSizes)
            {
                AssignedSizeDataList.Add(new AssignedSizeData
                {
                    SizeID = size.ID,
                    Name = size.Name,
                    Assigned = productSizes.Contains(size.ID)
                });
            }
        }

        public void UpdateProductSizes(OnlineFashionStoreContext context, string[] selectedSizes, Product itemToUpdate)
        {
            if (selectedSizes == null)
            {
                itemToUpdate.ProductSizes = new List<ProductSize>();
                return;
            }

            var selectedSizesHS = new HashSet<string>(selectedSizes);
            var productSizes = new HashSet<int>(itemToUpdate.ProductSizes.Select(c => c.SizeID));

            foreach (var size in context.Size)
            {
                if (selectedSizesHS.Contains(size.ID.ToString()))
                {
                    if (!productSizes.Contains(size.ID))
                    {
                        itemToUpdate.ProductSizes.Add(new ProductSize
                        {
                            ProductID = itemToUpdate.Id,
                            SizeID = size.ID
                        });
                    }
                }
                else
                {
                    if (productSizes.Contains(size.ID))
                    {
                        var sizeToRemove = itemToUpdate.ProductSizes
                            .SingleOrDefault(i => i.SizeID == size.ID);
                        context.Remove(sizeToRemove);
                    }
                }
            }
        }

    }
}
