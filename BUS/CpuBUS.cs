using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CpuBUS
    {
        public List<CPU> GetAll()
        {
            List<CPU> cpus = new CpuDAO().SelectAll();
            return cpus;
        }
        public CPU GetDetails(int id)
        {
            CPU cpu = new CpuDAO().SelectByCode(id);
            return cpu;
        }
        public List<CPU> Search(String keyword)
        {
            List<CPU> cpus = new CpuDAO().SelectByKeyword(keyword);
            return cpus;
        }
        public bool AddNew(CPU newCpu)
        {
            bool result = new CpuDAO().Insert(newCpu);
            return result;
        }
        public bool Update(CPU newCpu)
        {
            bool result = new CpuDAO().Update(newCpu);
            return result;
        }
        public bool Delete(int code)
        {
            bool result = new CpuDAO().Delete(code);
            return result;
        }
        public CPU Keyword(String name)
        {
            CPU cpus = new CpuDAO().SelectName(name);
            return cpus;
        }
    }
}
