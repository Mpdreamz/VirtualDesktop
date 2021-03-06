﻿using System;
using System.Collections.Generic;
using System.Linq;
using WindowsDesktop.Interop;
using JetBrains.Annotations;

namespace WindowsDesktop
{
	partial class VirtualDesktop
	{
		public static bool IsPinnedWindow(IntPtr hWnd)
		{
			VirtualDesktopHelper.ThrowIfNotSupported();

			return ComInterface.VirtualDesktopPinnedApps.IsViewPinned(hWnd.GetApplicationView());
		}

		public static void PinWindow(IntPtr hWnd)
		{
			VirtualDesktopHelper.ThrowIfNotSupported();

			var view = hWnd.GetApplicationView();

			if (!ComInterface.VirtualDesktopPinnedApps.IsViewPinned(view))
			{
				ComInterface.VirtualDesktopPinnedApps.PinView(view);
			}
		}

		public static void UnpinWindow(IntPtr hWnd)
		{
			VirtualDesktopHelper.ThrowIfNotSupported();

			var view = hWnd.GetApplicationView();

			if (ComInterface.VirtualDesktopPinnedApps.IsViewPinned(view))
			{
				ComInterface.VirtualDesktopPinnedApps.UnpinView(view);
			}
		}

		public static bool IsPinnedApplication([NotNull] string appId)
		{
			VirtualDesktopHelper.ThrowIfNotSupported();

			return ComInterface.VirtualDesktopPinnedApps.IsAppIdPinned(appId);
		}

		public static void PinApplication([NotNull] string appId)
		{
			VirtualDesktopHelper.ThrowIfNotSupported();

			if (!ComInterface.VirtualDesktopPinnedApps.IsAppIdPinned(appId))
			{
				ComInterface.VirtualDesktopPinnedApps.PinAppID(appId);
			}
		}

		public static void UnpinApplication([NotNull] string appId)
		{
			VirtualDesktopHelper.ThrowIfNotSupported();

			if (ComInterface.VirtualDesktopPinnedApps.IsAppIdPinned(appId))
			{
				ComInterface.VirtualDesktopPinnedApps.UnpinAppID(appId);
			}
		}
	}
}
