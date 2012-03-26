// -----------------------------------------------------------------------
// <copyright file="Services.svc.cs" company="Florian Amstutz">
// Copyright (c) Florian Amstutz. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;
using YAEM.Domain;

namespace YAEM.DesktopClient
{
    /// <summary>
    /// Contains a list of <see cref="User"/>.
    /// </summary>
    public class UserList : ObservableCollection<User>
    {
    }
}
