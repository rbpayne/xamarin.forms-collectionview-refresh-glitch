# Xamarin.Forms CollectionView Refresh Glitch (iOS)

This repo includes a small reproducible example of a Xamarin.Forms `CollectionView` animation glitch. The glitch occurs when an entire `CollectionView`—backed by an `ObservableCollection`—is cleared and then reloaded multiple times. The glitch occurs in iOS but not in Android.

I am posting this in the hope that the Xamarin.Forms team will be able to replicate and fix the issue. While there are [workarounds](#workaround), I feel that this is a core issue that should be solved at the root. I have [submitted an issue](https://github.com/xamarin/Xamarin.Forms/issues/14302) to the Xamarin.Forms GitHub repo.

![CollectionView glitches when refreshed multiple times](screen-recordings/refresh-multiple-times-v2.gif)

The glitch is a related to a label in the `CollectionView` with a visibility toggle (`IsVisible`):

```c#
<Label
  ...
  IsVisible="{Binding StarsAreVisible}" />
```

Items in the `CollectionView` that are deemed invisible still flash for a split second showing a blank green background.

## Additional Working Scenarios

The glitch does not appear when:

Items are added to the CollectionView:

![Adding items to the CollectionView](screen-recordings/add-items.gif)

Items are removed from the CollectionView:

![Removing items from the CollectionView](screen-recordings/remove-items.gif)

When the CollectionView is refreshed once:

![Refreshing the CollectionView once](screen-recordings/refresh-once.gif)

## Workarounds

### 1. Add Delay

Add a delay to the collection refresh. However, in a large scale production app this may not be feasible when using the Model View View Model (MVVM) architecture.

```c#
private async void ClearAndReloadRestaurants(object sender, EventArgs e)
{
    Restaurants.Clear();

    // This fixes the animation problem but may not scale in a larger app
    await Task.Delay(100);

    RefreshRestaurants();
}
```

### 2. Use a `StackLayout`

Instead of a `CollectionView`, use a `StackLayout` with a `BindableLayout` property. The tradeoff is that you lose the smooth animation when the collection is refreshed.

```xaml
<StackLayout Spacing="0" BindableLayout.ItemsSource="{Binding Restaurants}">
    <BindableLayout.ItemTemplate>
        ...
    </BindableLayout.ItemTemplate>
</StackLayout>
```
