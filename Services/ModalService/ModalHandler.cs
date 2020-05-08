using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace Culimancy.Services.ModalService
{
    public class ModalHandler
    {
        // Actions for Show/Close Events
        public event Action<string, RenderFragment, string> OnShow;
        public event Action OnClose;

        // Show Methods
        /// <summary>
        /// Launches a Modal with a <paramref name="contentType"/> and <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title">Title to display.</param>
        /// <param name="classSize">Size of Modal to render.</param>
        /// <param name="contentType">Component Class.</param>
        /// <param name="callback">Action to trigger on close.</param>
        public void Show<T>(string title, string classSize, Type contentType, Action<T> callback)
        {
            try
            {
                if (!typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException($"{contentType.FullName} must be a Component");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(1, contentType);
                    x.AddAttribute(3, "Callback", callback);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// Shows a Modal including a <paramref name="userSession"/>.
        /// </summary>
        /// <param name="title">The Title to display on the Modal.</param>
        /// <param name="classSize">The desired size, 'fuse-modal-md' is the default size, 'fuse-modal-xl' is full-screen. </param>
        /// <param name="contentType">The Razor Component to render within the Modal.</param>
        /// <param name="userSession">A UserSessionModel sent along with the modal for various uses.</param>
        public void Show(string title, string classSize, Type contentType)
        {
            try
            {
                if (!typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException($"{contentType.FullName} must be a Component");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(1, contentType);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Shows a Modal including a <paramref name="model"/> and a <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T">Generic Type for Model and Callback.</typeparam>
        /// <param name="title">Title of the Modal.</param>
        /// <param name="classSize">Modal size.</param>
        /// <param name="contentType">Type of Modal to launch.</param>
        /// <param name="model">Model to pass to the modal.</param>
        /// <param name="callback">Action using <paramref name="model"/> in the response.</param>
        public void Show<T>(string title, string classSize, Type contentType, T model, Action<T> callback)
        {
            try
            {
                if (!typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException($"{contentType.FullName} must be a Component");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(1, contentType);
                    x.AddAttribute(2, "Model", model);
                    x.AddAttribute(3, "Callback", callback);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Shows a Modal including a <paramref name="model"/> and a <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T">Generic Type for Model and Callback.</typeparam>
        /// <param name="title">Title of the Modal.</param>
        /// <param name="classSize">Modal size.</param>
        /// <param name="contentType">Type of Modal to launch.</param>
        /// <param name="model">Model to pass to the modal.</param>
        /// <param name="callback">Action using <paramref name="model"/> in the response.</param>
        public void Show<T, U>(string title, string classSize, Type contentType, T model, Action<U> callback)
        {
            try
            {
                if (!typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException($"{contentType.FullName} must be a Component");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(1, contentType);
                    x.AddAttribute(2, "Model", model);
                    x.AddAttribute(3, "Callback", callback);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

         /// <summary>
         /// Shows a Modal including a <paramref name="model"/>, a <paramref name="userSession"/>, and a <paramref name="callback"/>.
         /// </summary>
         /// <typeparam name="T">Model to be passed to the Razor Component.</typeparam>
         /// <typeparam name="U">Event Callback for returning data to the initiator.</typeparam>
         /// <param name="title">The Title to display on the Modal.</param>
         /// <param name="classSize">The desired size, 'fuse-modal-md' is the default size, 'fuse-modal-xl' is full-screen. </param>
         /// <param name="contentType">The Razor Component to render within the Modal.</param>
         /// <param name="model">A dynamic Model object to send to the rendered component.</param>
         /// <param name="userSession">A UserSessionModel sent along with the modal for various uses.</param>
         /// <param name="callback">A Event Callback for executing an event on the component that rendered the modal.</param>
        public void Show<T, U>(string title, string classSize, Type contentType, Action callback, U model)
        {
            try
            {
                if (!typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException($"{contentType.FullName} must be a Component");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(1, contentType);
                    x.AddAttribute(2, "Model", model);
                    x.AddAttribute(3, "Callback", callback);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Shows a Modal including a <paramref name="model"/>, <paramref name="userSession"/>, and <paramref name="userManager"/>.
        /// </summary>
        /// <typeparam name="T">Model to be passed to the Razor Component.</typeparam>
        /// <param name="title">The Title to display on the Modal.</param>
        /// <param name="classSize">The desired size, 'fuse-modal-md' is the default size, 'fuse-modal-xl' is full-screen. </param>
        /// <param name="contentType">The Razor Component to render within the Modal.</param>
        /// <param name="model">A dynamic Model object to send to the rendered component.</param>
        /// <param name="userSession">A UserSessionModel sent along with the modal for various uses.</param>
        /// <param name="userManager">A UserManager object for User Account management (Admin pages)</param>
        public void Show<T>(string title, string classSize, Type contentType, T model)
        {
            try
            {
                if (!typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException($"{contentType.FullName} must be a Component");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(1, contentType);
                    x.AddAttribute(2, "Model", model);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Shows a Modal including a <paramref name="model"/>, <paramref name="userSession"/>, <paramref name="userManager"/>, and <paramref name="callback"/>.
        /// </summary>
        /// <typeparam name="T">Model to be passed to the Razor Component.</typeparam>
        /// <typeparam name="U">Event Callback for returning data to the initiator.</typeparam>
        /// <param name="title">The Title to display on the Modal.</param>
        /// <param name="classSize">The desired size, 'fuse-modal-md' is the default size, 'fuse-modal-xl' is full-screen. </param>
        /// <param name="contentType">The Razor Component to render within the Modal.</param>
        /// <param name="model">A dynamic Model object to send to the rendered component.</param>
        /// <param name="userSession">A UserSessionModel sent along with the modal for various uses.</param>
        /// <param name="userManager">A UserManager object for User Account management (Admin pages)</param>
        /// <param name="callback">A Event Callback for executing an event on the component that rendered the modal.</param>
        public void Show<T, U>(string title, string classSize, Type contentType, Action<T> callback, U model)
        {
            try
            {
                if (!typeof(ComponentBase).IsAssignableFrom(contentType))
                {
                    throw new ArgumentException($"{contentType.FullName} must be a Component");
                }

                var content = new RenderFragment(x =>
                {
                    x.OpenComponent(1, contentType);
                    x.AddAttribute(2, "Model", model);
                    x.AddAttribute(3, "Callback", callback);
                    x.CloseComponent();
                });

                OnShow?.Invoke(title, content, classSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // Close Method
        public void Close()
        {
            OnClose?.Invoke();
        }
    }
}
