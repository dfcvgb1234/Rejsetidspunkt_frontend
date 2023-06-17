using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.Widget;
using JetBrains.Annotations;
using Rejsetidspunkt.Pages.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Platforms.Android
{
    public class WidgetProvider : AppWidgetProvider
    {
        public override void OnEnabled(Context context)
        {
            base.OnEnabled(context);
        }

        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            for (int i = 0; i < appWidgetIds.Length; i++)
            {
                int widgetId = appWidgetIds[i];

                Intent intent = new Intent(context, typeof(Main));
                PendingIntent pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);


                RemoteViews views = new RemoteViews(context.PackageName, 0);
                views.SetOnClickPendingIntent(0, pendingIntent);

                appWidgetManager.UpdateAppWidget(widgetId, views);
            }
            base.OnUpdate(context, appWidgetManager, appWidgetIds);
        }
    }
}
