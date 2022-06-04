using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.Repository.Repository;
using TheUCFour.Model.Model;

namespace TheUCFour.BLL.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public bool Add(Category category)
        {
           return _categoryRepository.Add(category);
        }
        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }
        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
        public bool ExistCategoryCode(Category category)
        {
            return _categoryRepository.ExistCategoryCode(category);
        }

        public bool ExistCategoryName(Category category)
        {
            return _categoryRepository.ExistCategoryName(category);
        }
    }
}
