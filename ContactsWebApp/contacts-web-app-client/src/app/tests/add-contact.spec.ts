import { test, expect } from '@playwright/test';

test('Edit Contact functionality', async ({ page }) => {
  await page.goto('http://localhost:4200');

  const firstContactEditButton = page.locator('tr:first-child p-button:has-text("Edit")');

  await firstContactEditButton.click();

  const dialog = page.locator('#editContactDialog');

  await dialog.locator('input#firstName').fill('Updated John');
  await dialog.locator('input#surname').fill('Updated Doe');
  await dialog.locator('input#address').fill('Updated Address');
  await dialog.locator('input#phoneNumber').fill('9876543210');
  await dialog.locator('input#iban').fill('DE44500105175407324931');

  await page.locator('p-button[type="submit"]:has-text("Edit")').click();

  const updatedContactRow = page.locator('tr:first-child');
  await expect(updatedContactRow.locator('td').nth(0)).toHaveText('Updated John');
  await expect(updatedContactRow.locator('td').nth(1)).toHaveText('Updated Doe');
  await expect(updatedContactRow.locator('td').nth(3)).toHaveText('Updated Address');
  await expect(updatedContactRow.locator('td').nth(4)).toHaveText('9876543210');
  await expect(updatedContactRow.locator('td').nth(5)).toHaveText('DE44500105175407324931');
});
