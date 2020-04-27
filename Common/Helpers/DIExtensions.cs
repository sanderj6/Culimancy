using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Helpers
{
    public static class DIExtensions
    {
        public static T GetServiceByType<T>(IEnumerable<T> Services, Type type)
        {
            foreach (var service in Services)
            {
                if (service.GetType() == type)
                {
                    return service;
                }
            }
            throw new Exception($"Type of {type.Name} was not found.");
        }
    }
}
